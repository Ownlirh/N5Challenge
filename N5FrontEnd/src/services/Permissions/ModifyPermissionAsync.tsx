import { EndpointsName } from '../../Models/Common/enums/ApiEndpoints';
import { AxiosCall } from '../../Models/Services/Axios/AxiosCall';
import { modifyPermissionFormData } from '../../pages/Permissions/ModifyPermission/schema/ModifyPermission.schema';
import { PutMethod } from '../Axios/AxiosService';

export const modifyPermissionAsync = async (
    permissionId: number,
    request: modifyPermissionFormData,
): Promise<AxiosCall<string>> => {
    const apiUrl = EndpointsName.PermissionsApi;

    return PutMethod(apiUrl, `api/permission/${permissionId}`, request);
};
