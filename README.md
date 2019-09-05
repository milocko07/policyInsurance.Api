# policyInsurance.Api
Back end example project to handle policy insurance

# Download .zip.
# Open with VS 2019 the policyInsurance.Api.sln file.
# Wait for restoring packages
# Remove the Migration folder (if it exists) that is located in policyInsurance.Api\policyInsurance.Data\Migrations folder
# Set default project policyInsurance.WebApi
# Compile
# Open Package Manager Console (powershell)
# Change Default project  to policyInsurance.WebApi
# Run following commands>
    Add-Migration NewMigration -Project policyInsurance.Data
    Update-Database –Verbose
# Play with F5 (IIS Express)
