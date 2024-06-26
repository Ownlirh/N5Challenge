import { EndpointsName } from '../../Models/Common/enums/ApiEndpoints';
import { AxiosCall } from '../../Models/Services/Axios/AxiosCall';
import { Permission } from '../../Models/Services/Permissions/Permission';
import { GetMethod } from '../Axios/AxiosService';

export const getPermissionById = async (
    permissionId: number,
): Promise<AxiosCall<Permission>> => {
    const apiUrl = EndpointsName.PermissionsApi;

    return GetMethod(apiUrl, `api/permission/${permissionId}`);
};
