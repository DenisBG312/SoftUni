DELETE ProductsClients
	WHERE ClientId = (Select Id FROM Clients WHERE NumberVAT LIKE 'IT%')


	DELETE Invoices
	WHERE ClientId = (Select Id FROM Clients WHERE NumberVAT LIKE 'IT%')

	DELETE Clients
	WHERE NumberVAT LIKE 'IT%'
