import { flexRender } from '@tanstack/react-table';
import { useGetPermissions } from './hooks/useGetPermissions';
import { useNavigate } from 'react-router-dom';

export const GetPermissions = () => {
    const navigate = useNavigate();
    const { table } = useGetPermissions();
    return (
        <div style={{ textAlign: 'center' }}>
            <div
                style={{
                    display: 'flex',
                    justifyContent: 'center',
                    padding: '15px',
                }}
            >
                <h1>Permissions</h1>;
                <button onClick={() => navigate('create')}>
                    Create Permission
                </button>
            </div>
            <div style={{ display: 'flex', justifyContent: 'center' }}>
                <table style={{ width: '70%', borderCollapse: 'collapse' }}>
                    <thead>
                        {table.getHeaderGroups().map((headerGroup) => (
                            <tr key={headerGroup.id}>
                                {headerGroup.headers.map((header) => (
                                    <th
                                        key={header.id}
                                        style={{
                                            border: '1px solid black',
                                            padding: '8px',
                                            textAlign: 'center',
                                        }}
                                    >
                                        {flexRender(
                                            header.column.columnDef.header,
                                            header.getContext(),
                                        )}
                                    </th>
                                ))}
                            </tr>
                        ))}
                    </thead>
                    <tbody>
                        {table.getRowModel().rows.map((row) => (
                            <tr key={row.id}>
                                {row.getVisibleCells().map((cell) => (
                                    <td
                                        key={cell.id}
                                        style={{
                                            border: '1px solid black',
                                            padding: '8px',
                                            textAlign: 'center',
                                        }}
                                    >
                                        {flexRender(
                                            cell.column.columnDef.cell,
                                            cell.getContext(),
                                        )}
                                    </td>
                                ))}
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};
