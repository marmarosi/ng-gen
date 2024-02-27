/* 3rd party libraries */
import { ComponentFixture, TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalSingle#Page } from './#dash-single#.page';

describe('#PascalSingle#Page', () => {
  let component: #PascalSingle#Page;
  let fixture: ComponentFixture<#PascalSingle#Page>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [#PascalSingle#Page]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(#PascalSingle#Page);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});