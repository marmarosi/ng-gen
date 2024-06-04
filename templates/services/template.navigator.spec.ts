import { TestBed } from '@angular/core/testing';

import { #PascalSingle#Navigator } from './#dash-single#.navigator';

describe('#PascalSingle#Navigator', () => {
  let navigator: #PascalSingle#Navigator;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    navigator = TestBed.inject(#PascalSingle#Navigator);
  });

  it('should be created', () => {
    expect(navigator).toBeTruthy();
  });
});
