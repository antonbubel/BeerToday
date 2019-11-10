import { getGreeting } from '../support/app.po';

describe('client-web', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    getGreeting().contains('Welcome to client-web!');
  });
});
