declare @total int
execute total_actors_from_given_category 'Action', @total OUT
select @total