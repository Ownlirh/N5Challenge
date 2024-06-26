import { EndpointsName } from '../../Models/Common/enums/ApiEndpoints';
import { AxiosCall } from '../../Models/Services/Axios/AxiosCall';
import { PermissionList } from '../../Models/Services/Permissions/PermissionList';
import { GetMethod } from '../Axios/AxiosService';

export const getPermissionsData = async (): Promise<
    AxiosCall<PermissionList>
> => {
    const apiUrl = EndpointsName.PermissionsApi;

    return GetMethod(apiUrl, 'api/permission');
};
