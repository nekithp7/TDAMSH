import { Injectable } from '@angular/core';
import {
	ConnectionBackend,
	RequestOptions,
	Request,
	RequestOptionsArgs,
	Response,
	Http,
	Headers
} from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { baseUrl } from './environment';
import { AuthService } from './auth.service';

@Injectable()
export class InterceptedHttp extends Http {
	constructor(backend: ConnectionBackend, defaultOptions: RequestOptions, private auth: AuthService) {
		super(backend, defaultOptions);
	}

	request(url: string | Request, options?: RequestOptionsArgs): Observable<Response> {
		return super.request(url, options);
	}

	get(url: string, options?: RequestOptionsArgs): Observable<Response> {
		url = this.updateUrl(url);
		return super.get(url, this.getRequestOptionArgs(options));
	}

	post(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
		url = this.updateUrl(url);
		return super.post(url, body, this.getRequestOptionArgs(options));
	}

	put(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
		url = this.updateUrl(url);
		return super.put(url, body, this.getRequestOptionArgs(options));
	}

	delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
		url = this.updateUrl(url);
		return super.delete(url, this.getRequestOptionArgs(options));
	}

	private updateUrl(req: string) {
		return baseUrl + req;
	}

	private getRequestOptionArgs(options?: RequestOptionsArgs): RequestOptionsArgs {
		if (options == null) {
			options = new RequestOptions();
		}
		if (options.headers == null) {
			options.headers = new Headers();
		}
		options.headers.append('Content-Type', 'application/json');
		options.headers.append('Authorization', `Bearer ${this.auth.getToken()}`);
		return options;
	}
}