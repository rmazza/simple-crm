import { of } from "rxjs";
import { GraphqlService } from "./graphql.service";

const graphqlStub = () => ({
    sendQuery: () => of()
});

export const GraphqlStubProvider = { provider: GraphqlService, useFactory: graphqlStub }