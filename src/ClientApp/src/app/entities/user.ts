export class User {
  firstName: string;
  middleName: string;
  lastName: string;
  constructor(fname: string, mname: string, lname: string) {
    this.firstName = fname;
    this.middleName = mname;
    this.lastName = lname;
  }

  getFullname() {
    let name: string = `${this.firstName}`;
    if (this.middleName) {
      name += ` ${this.middleName}`;
    }
    return `${name} ${this.lastName}`
  }
}
