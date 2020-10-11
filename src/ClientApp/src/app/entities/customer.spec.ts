import { Customer } from './customer';

describe('Customer', () => {
  const testId: string = "a57a0a68-835f-408a-b416-4b0d7a38dbac";
  const testUserId: number = 12345;

  it('should create an instance', () => {
    expect(new Customer(testId, testUserId)).toBeTruthy();
  });
});
