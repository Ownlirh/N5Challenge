import {
    createColumnHelper,
    getCoreRowModel,
    useReactTable,
} from '@tanstack/react-table';
import { Permission } from '../../../../Models/Services/Permissions/Permission';
import useFetchAndLoad from '../../../../hooks/useFetchAndLoad';
import { getPermissionsData } from '../../../../services/Permissions/GetPermissions';
import { PermissionList } from '../../../../Models/Services/Permissions/PermissionList';
import { useAsync } from '../../../../hooks/useAsync';
import { useState } from 'react';
import { formatDate } from '../../../../utilities/Dates/formatDate';
import { useNavigate } from 'react-router-dom';

export const useGetPermissions = () => {
    const [permissions, setPermissions] = useState<Permission[]>([]);
    const columnHelper = createColumnHelper<Permission>();

    const navigate = useNavigate();

    const { callEndpoint } = useFetchAndLoad();

    const getPermissionsAsync = async () => {
        return await callEndpoint(await getPermissionsData());
    };

    const handlePermissions = (data: PermissionList) => {
        setPermissions(data.permissions);
    };

    useAsync(
        getPermissionsAsync,
        handlePermissions,
        () => {},
        () => {},
        [],
    );

    const getPermissionsColumns = [
        columnHelper.accessor('id', {
            header: 'Identifier',
            cell: (info) => <span>{info.getValue()}</span>,
        }),
        columnHelper.accessor('name', {
            header: 'Name',
            cell: (info) => <span>{info.getValue()}</span>,
        }),
        columnHelper.accessor('surname', {
            header: 'Surname',
            cell: (info) => <span>{info.getValue()}</span>,
        }),
        columnHelper.accessor('permissionType', {
            header: 'Permission Type',
            cell: (info) => <span>{info.getValue()}</span>,
        }),
        columnHelper.accessor('createdAt', {
            header: 'CreatedAt',
            cell: (info) => <span>{formatDate(info.getValue())}</span>,
        }),
        columnHelper.display({
            id: 'Actions',
            header: 'Actions',
            size: 80,
            cell: (info) => (
                <button
                    onClick={() => navigate(`modify/${info.row.original.id}`)}
                >
                    Modify
                </button>
            ),
        }),
    ];

    const table = useReactTable({
        data: permissions ?? [],
        columns: getPermissionsColumns,
        getCoreRowModel: getCoreRowModel(),
    });

    return {
        table,
    };
};
