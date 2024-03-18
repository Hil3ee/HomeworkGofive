using Homework.Data;
using Homework.Models.Domain;
using Homework.Models.Dtos;
using Homework.Models.Dtos.Request;
using Homework.Models.Dtos.Response;
using Homework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Win32;
using System.Data;
using System.Security;
using Azure.Core;
using Microsoft.VisualBasic;
using System.Linq;
using System;

namespace Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;
        public HomeController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public IActionResult GetAllRole()
        {
            var roleDomain = DbContext.Roles.ToList();
            var roleDtos = new List<dataRole>();

            foreach (var role in roleDomain)
            {
                roleDtos.Add(new dataRole()
                {
                    roleId = role.roleId,
                    rolename = role.roleName,
                });
            }

            var response = new RoleDtoResponse()
            {
                Status = new Status
                {
                    code = "200",
                    description = "Success"
                },
                data = roleDtos.ToArray()
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllPermissions")]
        public IActionResult GetAllPermissions()
        {
            var permissionsDomain = DbContext.Permissions.ToList();
            var permissionsDtos = new List<PermisstionData>();

            foreach (var permission in permissionsDomain)
            {
                permissionsDtos.Add(new PermisstionData()
                {
                    permissionId = permission.permissionId,
                    permissionName = permission.permissionName,
                });
            }

            var response = new PermissionDtoResponse()
            {
                Status = new Status
                {
                    code = "200",
                    description = "Success"
                },
                data = permissionsDtos.ToArray()
            };
            return Ok(response);


        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(AddUserDtoRequest AdduserRequest)
        {
            bool allFieldsFilled = true;
            foreach (var field in new string[] {
                AdduserRequest.userid,
                AdduserRequest.firstname,
                AdduserRequest.lastname,
                AdduserRequest.email,
                AdduserRequest.username,
                AdduserRequest.password,
                AdduserRequest.roleid,
                AdduserRequest.permission[0].permissionid

            })
            {
                if (string.IsNullOrEmpty(field))
                {
                    allFieldsFilled = false;
                    break;
                }
            }

            var permissionnameCreate = AdduserRequest.userid + "-"
                                          + "r." + AdduserRequest.permission[0].isReadable + "-"
                                          + "w." + AdduserRequest.permission[0].isWritable + "-"
                                          + "d." + AdduserRequest.permission[0].isDeletable;

            if (allFieldsFilled == true) //Make sure the user has filled out all fields.
            {
                var checkuser = await DbContext.AddUsers.FirstOrDefaultAsync(u => u.userid == AdduserRequest.userid);
                if (checkuser == null) //Check the data in the database to make sure it is unique.
                {
                    var adduser = new Adduser
                    {
                        userid = AdduserRequest.userid,
                        firstname = AdduserRequest.firstname,
                        lastname = AdduserRequest.lastname,
                        email = AdduserRequest.email,
                        phone = AdduserRequest.phone,
                        username = AdduserRequest.username,
                        password = AdduserRequest.password,
                        roleId = AdduserRequest.roleid,
                        permissionId = AdduserRequest.permission[0].permissionid,
                        createdate = DateTime.Now.ToString("dd MMM, yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"))

                    };
                    DbContext.AddUsers.Add(adduser);

                    var addpermission = new Permission
                    {
                        permissionId = AdduserRequest.permission[0].permissionid,
                        permissionName = permissionnameCreate,
                        isReadable = AdduserRequest.permission[0].isReadable,
                        isWritable = AdduserRequest.permission[0].isWritable,
                        isDeletable = AdduserRequest.permission[0].isDeletable,
                    };
                    DbContext.Permissions.Add(addpermission);

                    await DbContext.SaveChangesAsync();

                    var rolaNameQuery = await DbContext.Roles
                            .Where(r => r.roleId == AdduserRequest.roleid)
                            .Select(r => r.roleName)
                            .FirstOrDefaultAsync();

                    var response = new AddUserDtoResponse
                    {
                        Status = new Status
                        {
                            code = "200",
                            description = "Success"
                        },
                        Data = new DataAdduserResponse[]
                        {
                            new DataAdduserResponse
                            {
                                userid = AdduserRequest.userid,
                                firstname = AdduserRequest.firstname,
                                lastname = AdduserRequest.lastname,
                                email = AdduserRequest.email,
                                phone = AdduserRequest.phone,
                                username = AdduserRequest.username,
                                password = AdduserRequest.password,
                                role = new RoleAddResponse
                                {
                                    roleId = AdduserRequest.roleid,
                                    roleName = rolaNameQuery
                                },
                                permisson = new PermissionAddResponse[]
                                {
                                    new PermissionAddResponse
                                    {
                                        permissionId = AdduserRequest.permission[0].permissionid,
                                        permissionName = permissionnameCreate,
                                    }
                                }


                            }
                        }
                    };

                    return Ok(response);
                }
                else
                {
                    return BadRequest("This user already exists in the database.");
                }
            }
            else
            {
                return BadRequest("Please fill in all fields.");
            }


        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserID cannot be null or empty");
            }
            else
            {
                var useridQuery = await DbContext.AddUsers.FirstOrDefaultAsync(u => u.userid == userId);
                if (useridQuery != null)
                {
                    DbContext.AddUsers.Remove(useridQuery);

                    var permission = await DbContext.Permissions.FirstOrDefaultAsync(p => p.permissionId == useridQuery.permissionId);
                    DbContext.Permissions.Remove(permission);

                    await DbContext.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("Your user was not found in the database.");
                }
            }

            var response = new DeleteUserDtoResponse
            {
                Status = new Status
                {
                    code = "200",
                    description = "Success"
                },
                Data = new DeleteData
                {
                    result = true,
                    message = "Successfully deleted",
                }
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("EditUser")]
        public async Task<IActionResult> Edituser(EditeUserDtoRequest editeUserDtoRequest, string id)
        {
            var userIdquery = await DbContext.AddUsers
                            .Where(u => u.userid == id)
                            .Select(u => u.userid)
                            .FirstOrDefaultAsync();

            var permissionnameCreate = id + "-"
                                          + "r." + editeUserDtoRequest.permission[0].isReadable + "-"
                                          + "w." + editeUserDtoRequest.permission[0].isWritable + "-"
                                          + "d." + editeUserDtoRequest.permission[0].isDeletable;

            bool allFieldsFilled = true;

            foreach (var field in new string[] {
                editeUserDtoRequest.firstname,
                editeUserDtoRequest.lastname,
                editeUserDtoRequest.email,
                editeUserDtoRequest.username,
                editeUserDtoRequest.password,
                editeUserDtoRequest.roleid,
                editeUserDtoRequest.permission[0].permissionid

            })
            {
                if (string.IsNullOrEmpty(field))
                {
                    allFieldsFilled = false;
                    break;
                }
            }

            //Check that the userid received matches the one in the databases.
            if (userIdquery != null)
            {
                //Check that all received values ​​are not null.
                if (allFieldsFilled == true)
                {
                    var datauser = new Adduser
                    {
                        userid = id,
                        firstname = editeUserDtoRequest.firstname,
                        lastname = editeUserDtoRequest.lastname,
                        email = editeUserDtoRequest.email,
                        phone = editeUserDtoRequest.phone,
                        username = editeUserDtoRequest.username,
                        password = editeUserDtoRequest.password,
                        roleId = editeUserDtoRequest.roleid,
                        permissionId = editeUserDtoRequest.permission[0].permissionid,
                    };
                    DbContext.AddUsers.Update(datauser);

                    var permissiondata = new Permission
                    {
                        permissionId = editeUserDtoRequest.permission[0].permissionid,
                        permissionName = permissionnameCreate,
                        isReadable = editeUserDtoRequest.permission[0].isReadable,
                        isWritable = editeUserDtoRequest.permission[0].isWritable,
                        isDeletable = editeUserDtoRequest.permission[0].isDeletable,
                    };
                    DbContext.Permissions.Update(permissiondata);

                    await DbContext.SaveChangesAsync();

                    var response = new EditUserDtoResponse
                    {
                        Status = new Status
                        {
                            code = "200",
                            description = "Success"
                        },
                        Data = new DataPermissionEditResponse[]
                        {
                        new DataPermissionEditResponse
                        {
                            firstname = editeUserDtoRequest.firstname,
                            lastname = editeUserDtoRequest.lastname,
                            email = editeUserDtoRequest.email,
                            phone = editeUserDtoRequest.phone,
                            username = editeUserDtoRequest.username,
                            password = editeUserDtoRequest.password,
                            role = new RoleEditResponse
                            {
                                roleid = editeUserDtoRequest.roleid,
                                rolename =  await DbContext.Roles.Where(r => r.roleId == editeUserDtoRequest.roleid).Select(r => r.roleName).FirstOrDefaultAsync()
                            },
                            permission = new PermissionEditResponse[]
                                      {
                                            new PermissionEditResponse
                                            {
                                                permissionId = editeUserDtoRequest.permission[0].permissionid,
                                                permissionName = permissionnameCreate
                                            }
                                      }
                        }
                        }
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Please fill in all fields.");
                }

            }
            else
            {
                return BadRequest("Your information was not found in the database.");
            }

        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserID cannot be null or empty");
            }
            else
            {
                var getUserQuery = await (from a in DbContext.AddUsers
                                          join p in DbContext.Permissions on a.permissionId equals p.permissionId
                                          join r in DbContext.Roles on a.roleId equals r.roleId
                                          where a.userid == userId
                                          select new
                                          {
                                              userdata = a,
                                              r.roleName,
                                              p.permissionName,
                                          }).FirstOrDefaultAsync();

                if (getUserQuery != null)
                {
                    var response = new AddUserDtoResponse
                    {
                        Status = new Status
                        {
                            code = "200",
                            description = "Success"
                        },
                        Data = new DataAdduserResponse[]
                        {
                            new DataAdduserResponse
                            {
                                userid = userId,
                                firstname = getUserQuery.userdata.firstname,
                                lastname = getUserQuery.userdata.lastname,
                                email = getUserQuery.userdata.email,
                                phone = getUserQuery.userdata.phone,
                                role = new RoleAddResponse
                                {
                                    roleId = getUserQuery.userdata.roleId,
                                    roleName = getUserQuery.roleName,
                                },
                                username = getUserQuery.userdata.username,
                                permisson = new PermissionAddResponse[]
                                {
                                    new PermissionAddResponse
                                    {
                                        permissionId = getUserQuery.userdata.permissionId,
                                        permissionName = getUserQuery.permissionName,
                                    }
                                }
                            }
                        }
                    };

                    return Ok(response);
                }
                else
                {
                    return BadRequest("Your user was not found in the database.");
                }
            }


        }

        [HttpPost]
        [Route("DataTable")]
        public async Task<IActionResult> DataTable(GetUserPageDtoRequest request)
        {
            var search = request.search;
            var query = from a in DbContext.AddUsers
                        join p in DbContext.Permissions on a.permissionId equals p.permissionId
                        join r in DbContext.Roles on a.roleId equals r.roleId
                        where (string.Concat(a.firstname, " ", a.lastname) == search ||
                              a.email == search ||
                              a.firstname == search ||
                              a.lastname == search ||
                              p.permissionName == search ||
                              r.roleName == search)
                        select new
                        {
                            userTable = a,
                            roleName = r.roleName,
                            permissionName = p.permissionName
                        };
            
            var orderDirection = "ascending";
            if (request.orderDirection == "descending")
            {
                orderDirection = "descending";
            }

            var orderBy = request.orderBy.ToLower();

            switch (orderBy)
            {
                case "userid":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.userid) : query.OrderBy(a => a.userTable.userid);
                    break;
                case "firstname":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.firstname) : query.OrderBy(a => a.userTable.firstname);
                    break;
                case "lastname":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.lastname) : query.OrderBy(a => a.userTable.lastname);
                    break;
                case "email":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.email) : query.OrderBy(a => a.userTable.email);
                    break;
                case "roleid":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.roleId) : query.OrderBy(a => a.userTable.roleId);
                    break;
                case "rolename":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.roleName) : query.OrderBy(a => a.roleName);
                    break;
                case "username":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.username) : query.OrderBy(a => a.userTable.username);
                    break;
                case "permission":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.userTable.permissionId) : query.OrderBy(a => a.userTable.permissionId);
                    break;
                case "permissionname":
                    query = orderDirection == "descending" ? query.OrderByDescending(a => a.permissionName) : query.OrderBy(a => a.permissionName);
                    break;
            }


            var usersQuery = query
                .Skip((request.pageNumber.Value - 1) * request.pageSize.Value)
                .Take(request.pageSize.Value)
                .ToList();



            var dataCount = await DbContext.AddUsers.CountAsync();
            double pagetotal = Math.Ceiling((double)dataCount / (double)request.pageSize);

            var response = new GetUserPageDtoResponse
            {
                dataSource = usersQuery.Select(u => new DataPage
                {
                    UserId = u.userTable.userid,
                    firstname = u.userTable.firstname,
                    lastname = u.userTable.lastname,
                    email = u.userTable.email,
                    role = new RoleAddResponse
                    {
                        roleId = u.userTable.roleId,
                        roleName = u.roleName,
                    },
                    username = u.userTable.username,
                    permission = new PermissionAddResponse[]
                    {
                        new PermissionAddResponse
                        {
                            permissionId = u.userTable.permissionId,
                            permissionName = u.permissionName,
                        }
                    },
                    createdDate = u.userTable.createdate

                }).ToArray(),
                page = (int)request.pageNumber,
                pageSize = (int)request.pageSize,
                totalCount = Convert.ToInt32(pagetotal),
            };
            return Ok(response);
        }

   //test git again
    }

    
}
