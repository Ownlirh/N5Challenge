import { Route, Routes } from 'react-router-dom';
import { CreatePermissions } from './CreatePermission/CreatePermission';
import { GetPermissions } from './GetPermissions/GetPermissions';
import { ModifyPermissions } from './ModifyPermission/ModifyPermission';

export const Permissions = () => {
    return (
        <Routes>
            <Route index element={<GetPermissions />} />
            <Route path="create" element={<CreatePermissions />} />
            <Route path="modify/:id" element={<ModifyPermissions />} />
        </Routes>
    );
};

export default Permissions;
