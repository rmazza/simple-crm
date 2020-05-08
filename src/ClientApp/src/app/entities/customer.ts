export class Customer {
  private id: string = null;

  constructor(
    public firstName: string,
    public lastName: string,
    public middleName: string
  ) { }

  getId(): string {
    return this.id;
  }
}
