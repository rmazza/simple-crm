import { Email } from './email';

describe('Email', () => {
  it('should create an instance', () => {
    expect(new Email("personal", "test@email.com")).toBeTruthy();
  });

  describe('getId', () => {
    it('should return id', () => {
      const id = '12345';
      const email = new Email("personal", "test@email.com");
      email['id'] = id;
      expect(email.getId()).toBe(id);
    })
  });
});
