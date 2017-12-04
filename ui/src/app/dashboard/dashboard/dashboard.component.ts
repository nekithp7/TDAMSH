import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../core/auth.service';

@Component({
	templateUrl: './dashboard.component.html',
	styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
	constructor(private authService: AuthService, private router: Router) { }

	logOut(): void {
		this.authService.logOut();
		this.router.navigateByUrl('auth/login');
	}
}
