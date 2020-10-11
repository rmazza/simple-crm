import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { CustomerAddComponent } from './customer-add.component';
import { GraphqlStubProvider } from '../../services/grahql/graphql.stub';
import { MessageService } from 'primeng/api';
import { GetBaseUrlStubProvider } from '../../../shared/testing/stubs/shared.stubs';

describe('CustomerAddComponent', () => {
  let component: CustomerAddComponent;
  let fixture: ComponentFixture<CustomerAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule, RouterTestingModule ],
      declarations: [ CustomerAddComponent ],
      providers: [
        GraphqlStubProvider,
        MessageService,
        GetBaseUrlStubProvider,
        FormBuilder
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
