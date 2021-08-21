import { ApiMethod, KeyValue, MetaData } from "../type";

export class APIServices {

    private _method: ApiMethod = "POST";
    private _headers: string[][] = [];

    constructor(private _authToken: string) {
        this.setHeaders([
            {
                key: 'Accept',
                value: 'application/json'
            }, {
                key: 'Content-Type',
                value: 'application/json'
            },
        ]);
    }
    get authToken(): string {
        return this._authToken;
    }

    set authToken(newAuthToken: string) {
        this._authToken = newAuthToken;
    }

    get headers(): string[][] {
        return this._headers;
    }

    set method(newMethod: ApiMethod) {
        this._method = newMethod;
    }

    public setHeaders(headers: KeyValue<string, string>[]): APIServices {
        for (const i in headers) {
            if (headers[i].hasOwnProperty('key')
                && headers[i].hasOwnProperty('value')) {
                this._headers.push([headers[i].key, headers[i].value]);
            }
        }
        return this;
    }

    public resetHeaders(): void {
        this._headers = [];
    }

    public setMethod(newMethod: ApiMethod): APIServices {
        this._method = newMethod;
        return this;
    }

    public request<T>(body: T): RequestInit {
        return {
            headers: this._headers,
            method: this._method,
            body: JSON.stringify(body),
        }
    }
}

export class RequestBody<T> {

    constructor(private Payload: T) {
    }
    get payload(): T {
        return this.Payload;
    }

    set payload(newRequestBody: T) {
        this.Payload = newRequestBody;
    }
}

export default APIServices;