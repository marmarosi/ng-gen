/* 3rd party libraries */
import { ComponentFixture, TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalSingle#Dialog } from './#dash-single#.dialog';

describe('#PascalSingle#Dialog', () => {
  let component: #PascalSingle#Dialog;
  let fixture: ComponentFixture<#PascalSingle#Dialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ #PascalSingle#Dialog ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(#PascalSingle#Dialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});