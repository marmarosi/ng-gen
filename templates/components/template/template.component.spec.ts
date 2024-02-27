/* 3rd party libraries */
import { ComponentFixture, TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalSingle##PascalType# } from './#dash-single#.#dash-type#';

describe('#PascalSingle##PascalType#', () => {
  let #camelType#: #PascalSingle##PascalType#;
  let fixture: #PascalType#Fixture<#PascalSingle##PascalType#>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [#PascalSingle##PascalType#]
    })
    .compile#PascalType#s();
    
    fixture = TestBed.create#PascalType#(#PascalSingle##PascalType#);
    #camelType# = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(#camelType#).toBeTruthy();
  });
});