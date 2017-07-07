import { IlenaPage } from './app.po';

describe('ilena App', () => {
  let page: IlenaPage;

  beforeEach(() => {
    page = new IlenaPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
