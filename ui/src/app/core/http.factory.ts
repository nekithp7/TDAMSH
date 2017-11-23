import { XHRBackend, Http, RequestOptions } from '@angular/http';
import { InterceptedHttp } from './http.interceptor';
import { AuthService } from './auth.service';

export function httpFactory(xhrBackend: XHRBackend, requestOptions: RequestOptions, auth: AuthService): Http {
	return new InterceptedHttp(xhrBackend, requestOptions, auth);
}
