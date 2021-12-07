import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductImageDialogComponent } from './add-product-image-dialog.component';

describe('AddProductImageDialogComponent', () => {
  let component: AddProductImageDialogComponent;
  let fixture: ComponentFixture<AddProductImageDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProductImageDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProductImageDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
