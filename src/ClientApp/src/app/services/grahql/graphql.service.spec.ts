import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { GraphqlService } from './graphql.service';
import { GraphqlStubProvider } from './graphql.stub';

describe('GraphqlService', () => {
  let service: GraphqlService;
  const getBaseUrlStub = () => "/";

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        GraphqlStubProvider,
        { provide: 'BASE_URL', useFactory: getBaseUrlStub }
      ],
      declarations: []
    });
    service = TestBed.inject(GraphqlService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
