import { useState } from 'react';
import { Permission } from '../../../../Models/Services/Permissions/Permission';
import useFetchAndLoad from '../../../../hooks/useFetchAndLoad';
import { getPermissionById } from '../../../../services/Permissions/GetPermissionById';
import { useAsync } from '../../../../hooks/useAsync';
import { useForm } from 'react-hook-form';
import {
    modifyPermissionFormData,
    modifyPermissionSchema,
} from '../schema/ModifyPermission.schema';
import { zodResolver } from '@hookform/resolvers/zod';
import { PermissionType } from '../../../../Models/Services/PermissionsType/PermissionType';
import { getPermissionTypes } from '../../../../services/PermissionsType/GetPermissionTypes';
import { modifyPermissionAsync } from '../../../../services/Permissions/ModifyPermissionAsync';
import { useNavigate } from 'react-router-dom';

export const useModifyPermissions = (permissionId: number) => {
    const navigate = useNavigate();
    const [permissionTypes, setPermissionTypes] = useState<PermissionType[]>(
        [],
    );
    const { callEndpoint } = useFetchAndLoad();

    const getPermissionsTypesAsync = async () => {
        return await callEndpoint(await getPermissionTypes());
    };

    const handlePermissionsTypes = (data: PermissionType[]) => {
        setPermissionTypes(data);
    };

    useAsync(
        getPermissionsTypesAsync,
        handlePermissionsTypes,
        () => {},
        () => {},
        [],
    );

    const {
        register,
        handleSubmit,
        setValue,
        formState: { errors },
    } = useForm<modifyPermissionFormData>({
        resolver: zodResolver(modifyPermissionSchema),
    });

    const getPermissionByIdAsync = async () => {
        return await callEndpoint(await getPermissionById(permissionId));
    };

    const handlePermissionById = (data: Permission) => {
        setValue('name', data.name);
        setValue('surname', data.surname);
        setValue('permissionTypeId', data.permissionId);
    };

    useAsync(
        getPermissionByIdAsync,
        handlePermissionById,
        () => {},
        () => {},
        [],
    );

    const onSubmit = async (data: modifyPermissionFormData) => {
        await callEndpoint(await modifyPermissionAsync(permissionId, data));

        navigate('..');
    };

    return {
        register,
        handleSubmit,
        errors,
        onSubmit,
        permissionTypes,
    };
};
