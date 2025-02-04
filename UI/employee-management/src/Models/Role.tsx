import { Employee } from "./Employee";
import { RolePermission } from "./RolePermission";

export class Role {
    constructor(
        public roleId: number,
        public roleName: string,
        private rolePermissions: RolePermission[] = [],
        private employees: Employee[] = []
    ) {}

}