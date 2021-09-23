SELECT A.*
FROM actor A
	INNER JOIN 
(SELECT TOP 5 A.actor_id, COUNT(*) AS TOTAL
FROM actor AS A
	INNER JOIN  film_actor AS FA ON FA.actor_id = A.actor_id
GROUP BY A.actor_id
ORDER BY TOTAL DESC) FILMES ON FILMES.actor_id = A.actor_id
