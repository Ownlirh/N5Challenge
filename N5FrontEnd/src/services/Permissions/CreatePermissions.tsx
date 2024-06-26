import { EndpointsName } from '../../Models/Common/enums/ApiEndpoints';
import { AxiosCall } from '../../Models/Services/Axios/AxiosCall';
import { createPermissionFormData } from '../../pages/Permissions/CreatePermission/schema/CreatePermission.schema';
import { PostMethod } from '../Axios/AxiosService';

export const createPermissionAsync = async (
    request: createPermissionFormData,
): Promise<AxiosCall<string>> => {
    const apiUrl = EndpointsName.PermissionsApi;

    return PostMethod(apiUrl, 'api/permission', request);
};
