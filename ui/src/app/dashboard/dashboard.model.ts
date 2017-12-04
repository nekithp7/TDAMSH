export interface IDashboard {
	narrative: string;
}

export class Dashboard implements IDashboard {
	public narrative: string;

	constructor(dashboard?: IDashboard) {
		this.narrative = dashboard && dashboard.narrative;
	}

}
