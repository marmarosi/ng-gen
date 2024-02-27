import { TestBed } from '@angular/core/testing';

import { #PascalSingle#Navigator } from './#dash-single#.navigator';

describe('#PascalSingle#Navigator', () => {
  let #camelSingle#: #PascalSingle#Navigator;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    #camelSingle# = TestBed.inject(#PascalSingle#Navigator);
  });

  it('should be created', () => {
    expect(#camelSingle#).toBeTruthy();
  });
});