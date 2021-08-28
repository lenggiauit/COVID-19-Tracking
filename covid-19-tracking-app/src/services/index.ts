import { BaseQueryFn } from '@reduxjs/toolkit/query';
const CovidBaseQuery: BaseQueryFn<
    string, // Args
    unknown, // Result
    { reason: string }, // Error
    { shout?: boolean }, // DefinitionExtraOptions
    { timestamp: number } // Meta
> = (arg, api, extraOptions) => {
    // `arg` has the type `string`
    // `api` has the type `BaseQueryApi` (not configurable)
    // `extraOptions` has the type `{ shout?: boolean }

    const meta = { timestamp: Date.now() }

    if (arg === 'forceFail') {
        return {
            error: {
                reason: 'Intentionally requested to fail!',
                meta,
            },
        }
    }

    if (extraOptions.shout) {
        return { data: 'CONGRATULATIONS', meta }
    }

    return { data: 'congratulations', meta }
}

