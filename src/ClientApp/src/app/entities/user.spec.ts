import { User } from './user';

describe('User', () => {
  it('should create an instance', () => {
    expect(new User('firstName', 'middleName', 'lastName')).toBeTruthy();
  });

  describe('getFullName', () => {
    it('should return full name', () => {
      const user = new User('firstName', 'middleName', 'lastName');
      expect(user.getFullname()).toBe('firstName middleName lastName');
    })
  });
});
