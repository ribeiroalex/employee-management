import { Role } from "./Role";

export class RolePermission {
    constructor(
        public roleId: number,
        public role: Role,
        public canCreateRoleId: number,
        public canCreateRole: Role
    ) {}
}