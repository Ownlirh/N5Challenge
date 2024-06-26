import axios from 'axios';

export async function GetMethod<responseType>(apiUrl: string, path?: string) {
    const finalUrl = createFinalUrl(apiUrl, path ?? '');
    const controller = new AbortController();

    return {
        call: axios.get<responseType>(finalUrl, {
            signal: controller.signal,
        }),
        controller,
    };
}

export async function PostMethod<requestData, responseType>(
    apiUrl: string,
    path?: string,
    body?: requestData,
) {
    const finalUrl = createFinalUrl(apiUrl, path ?? '');
    const controller = new AbortController();

    if (body !== undefined) {
        return {
            call: axios.post<requestData, responseType>(finalUrl, body, {
                signal: controller.signal,
            }),
            controller,
        };
    }

    return {
        call: axios.post<requestData, responseType>(
            finalUrl,
            {},
            { signal: controller.signal },
        ),
        controller,
    };
}

export async function PutMethod<requestData, responseType>(
    apiUrl: string,
    path?: string,
    body?: requestData,
) {
    const finalUrl = createFinalUrl(apiUrl, path ?? '');
    const controller = new AbortController();

    if (body !== undefined) {
        return {
            call: axios.put<requestData, responseType>(finalUrl, body, {
                signal: controller.signal,
            }),
            controller,
        };
    }

    return {
        call: axios.post<requestData, responseType>(
            finalUrl,
            {},
            { signal: controller.signal },
        ),
        controller,
    };
}

export function createFinalUrl(apiUrl: string, path: string): string {
    return apiUrl.concat(path);
}
