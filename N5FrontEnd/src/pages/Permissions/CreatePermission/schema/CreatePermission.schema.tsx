import { z } from 'zod';

export const createPermissionSchema = z.object({
    name: z.string().min(1, 'Name is required'),
    surname: z.string().min(1, 'Surname is required'),
    permissionTypeId: z.number().min(1, 'Permission type is required'),
});

export type createPermissionFormData = z.infer<typeof createPermissionSchema>;
