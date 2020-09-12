import { Email } from './email';

export class Customer {
  private id: string = null;
  private userId: number;
  public emailAddresses: Email[];

  constructor(
    public firstName: string,
    public lastName: string,
    public middleName: string
  ) { }

  public get Id(): string {
    return this.id;
  }
}