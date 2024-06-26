import { useState } from 'react';
import { PermissionType } from '../../../../Models/Services/PermissionsType/PermissionType';
import useFetchAndLoad from '../../../../hooks/useFetchAndLoad';
import { getPermissionTypes } from '../../../../services/PermissionsType/GetPermissionTypes';
import { useAsync } from '../../../../hooks/useAsync';
import { SubmitHandler, useForm } from 'react-hook-form';
import {
    createPermissionFormData,
    createPermissionSchema,
} from '../schema/CreatePermission.schema';
import { zodResolver } from '@hookform/resolvers/zod';
import { createPermissionAsync } from '../../../../services/Permissions/CreatePermissions';
import { useNavigate } from 'react-router-dom';

export const useCreatePermissions = () => {
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
        formState: { errors },
    } = useForm<createPermissionFormData>({
        resolver: zodResolver(createPermissionSchema),
    });

    const onSubmit: SubmitHandler<createPermissionFormData> = async (data) => {
        await callEndpoint(await createPermissionAsync(data));
        navigate('..');
    };

    return {
        permissionTypes,
        register,
        handleSubmit,
        onSubmit,
        errors,
    };
};
