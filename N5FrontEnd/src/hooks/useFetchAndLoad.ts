import type { AxiosResponse } from 'axios';
import { useEffect, useState } from 'react';
import { AxiosCall } from '../Models/Services/Axios/AxiosCall';

const useFetchAndLoad = () => {
    const [loading, setLoading] = useState(false);
    let controller: AbortController;

    const callEndpoint = async <T>(axiosCall: AxiosCall<T>) => {
        setLoading(true);
        if (axiosCall?.controller != null) controller = axiosCall.controller;
        let result: AxiosResponse<T>;
        try {
            result = await axiosCall.call;
        } catch (err: unknown) {
            setLoading(false);
            throw err;
        }
        setLoading(false);
        return result;
    };

    const cancelEndpoint = () => {
        setLoading(false);
        if (controller != null) {
            controller.abort();
        }
    };

    useEffect(() => {
        return () => {
            cancelEndpoint();
        };
        /* eslint-disable */
    }, []);

    return { loading, callEndpoint };
};

export default useFetchAndLoad;
