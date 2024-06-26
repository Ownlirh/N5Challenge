import type { AxiosResponse } from 'axios';
import { useEffect } from 'react';

export const useAsync = <T,>(
    asyncFn: () => Promise<AxiosResponse<T>>,
    successFunction: (data: T) => unknown,
    returnFuntion?: () => unknown,
    errorFunction?: () => unknown,
    dependencies: unknown[] = [],
) => {
    useEffect(() => {
        let isActive = true;
        asyncFn()
            .then((result) => {
                if (isActive) successFunction(result.data);
            })
            .catch((error) => {
                console.error(error);
                if (errorFunction != null) {
                    errorFunction();
                } else {
                    void 0;
                }
            });
        return () => {
            if (returnFuntion != null) {
                returnFuntion();
            }
            void 0;
            isActive = false;
        };
        /* eslint-disable */
    }, dependencies);
};
