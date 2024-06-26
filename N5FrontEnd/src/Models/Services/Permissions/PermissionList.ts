import { Permission } from './Permission';

export interface PermissionList {
    limit: number;
    total: number;
    permissions: Permission[];
}
