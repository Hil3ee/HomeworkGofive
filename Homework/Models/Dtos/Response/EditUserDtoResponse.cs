﻿using Homework.Models.Dtos.Request;

namespace Homework.Models.Dtos.Response
{
    public class EditUserDtoResponse
    {
        public Status Status { get; set; }
        public DataEditResponse Data { get; set; }
    }

    public class PermissionEditResponse
    {
        public string permissionId { get; set; }
        public string permissionName { get; set; }
    }

    public class RoleEditResponse 
    {
        public string roleid { get; set;}
        public string rolename { get; set; }
    }

    public class DataEditResponse
    {
        public string userId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public RoleEditResponse role { get; set; }
        public string username { get; set; }
        public PermissionEditResponse[] permission { get; set; }
    }
}
