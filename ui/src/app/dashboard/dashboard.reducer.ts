
import { Action } from '@ngrx/store';
import { Dashboard } from './dashboard.model';


export type DashboardState = Dashboard;

const initialState: Dashboard = new Dashboard();

export default function (state: Dashboard = initialState, action: Action): DashboardState {
	switch (action.type) {
		default: {
			return state;
		}
	}
}
