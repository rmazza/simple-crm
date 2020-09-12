export class Queries {
    public static CustomerQueries = {
        get: `{
            customers {
                id
                userId
                firstName
                lastName
            }
          }`,
        mutation: {
            delete: (id: string) => ({
                query: `mutation ($id:Id!) {
                            deleteCustomer(id:$id) {
                                id
                            }
                        }`,
                variables: { id: id }
            })
        }
    };
}


const addCustomerMutation: string = `
  mutation ($customer:CustomerInput!) {
    addCustomer(customer:$customer) {
      id
    }
  }`;