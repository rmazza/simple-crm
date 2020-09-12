export class Email {
    private id: string;

    constructor(
      public type: string,
      public email: string
    ) { }
  
    getId(): string {
      return this.id;
    }
}
