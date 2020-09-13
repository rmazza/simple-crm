import { Email } from './email';

export class Customer {
  private id: string = null;
  private userId: number;
  public emailAddresses: Email[];


  constructor(
    id: string,
    userId: number,
    public firstName?: string,
    public lastName?: string
  ) { }

  public get Id(): string {
    return this.id;
  }

  public get UserId(): number {
    return this.userId;
  }
}