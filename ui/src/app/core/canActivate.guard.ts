import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

	constructor(private router: Router, private auth: AuthService) {
	}

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
		if (this.auth.isLogedIn()) {
			return true;
		}
		this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
		return false;
	}

	canLoad(route: ActivatedRouteSnapshot) {
		if (this.auth.isLogedIn()) {
			return true;
		}
		this.router.navigate(['/auth/login']);
		return false;
	}
}
