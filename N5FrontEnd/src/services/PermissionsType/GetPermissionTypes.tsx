import { EndpointsName } from '../../Models/Common/enums/ApiEndpoints';
import { AxiosCall } from '../../Models/Services/Axios/AxiosCall';
import { PermissionType } from '../../Models/Services/PermissionsType/PermissionType';
import { GetMethod } from '../Axios/AxiosService';

export const getPermissionTypes = async (): Promise<
    AxiosCall<PermissionType[]>
> => {
    const apiUrl = EndpointsName.PermissionsApi;

    return GetMethod(apiUrl, 'api/permission-types');
};
