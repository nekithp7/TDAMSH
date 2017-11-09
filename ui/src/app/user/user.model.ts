export interface IUser {
	id: string;
	name: string;
	surname?: string;
	email: string;
}

export class User implements IUser {
	public id: string;
	public name: string;
	public surname?: string;
	public email: string;

	constructor (user?: IUser) {
		this.id = user && user.id;
		this.name = (user && user.name) || '';
		this.surname = (user && user.surname) || '';
		this.email = (user && user.email) || '';
	}

}
