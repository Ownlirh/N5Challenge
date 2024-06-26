import { useParams } from 'react-router-dom';
import { useModifyPermissions } from './hooks/useModifyPermissions';

export const ModifyPermissions = () => {
    const { id } = useParams<{ id?: string }>();

    const processId = Number(id ?? 0);
    const { register, handleSubmit, errors, onSubmit, permissionTypes } =
        useModifyPermissions(processId);

    return (
        <>
            <h1>Modify Permissions</h1>
            <div>
                <h1> Create Permission</h1>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <div>
                        <label htmlFor="name">Name</label>
                        <input id="name" {...register('name')} />
                        {errors.name && <p>{errors.name.message}</p>}
                    </div>
                    <div>
                        <label htmlFor="surname">Surname</label>
                        <input id="surname" {...register('surname')} />
                        {errors.surname && <p>{errors.surname.message}</p>}
                    </div>
                    <div>
                        <label htmlFor="selectedPermissionType">
                            Select an option
                        </label>
                        <select
                            id="selectedPermissionType"
                            {...register('permissionTypeId', {
                                required: 'Please select an option',
                                setValueAs: (value) => Number(value),
                            })}
                        >
                            {permissionTypes.map((option) => (
                                <option key={option.id} value={option.id}>
                                    {option.description}
                                </option>
                            ))}
                        </select>
                        {errors.permissionTypeId && (
                            <p>{errors.permissionTypeId.message}</p>
                        )}
                    </div>
                    <button type="submit">Submit</button>
                </form>
            </div>
        </>
    );
};
