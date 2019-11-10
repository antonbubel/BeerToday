import { getGreeting } from '../support/app.po';

describe('client-mobile', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    getGreeting().contains('Welcome to client-mobile!');
  });
});
