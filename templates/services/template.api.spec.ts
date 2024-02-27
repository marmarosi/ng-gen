import { TestBed } from '@angular/core/testing';

import { #PascalSingle#Api } from './#dash-single#.api';

describe('#PascalSingle#Api', () => {
  let api: #PascalSingle#Api;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    api = TestBed.inject(#PascalSingle#Api);
  });

  it('should be created', () => {
    expect(api).toBeTruthy();
  });
});