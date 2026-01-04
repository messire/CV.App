import {Container, Input, InputGroup, SimpleGrid, Text, VStack} from "@chakra-ui/react";
import {Link} from "react-router-dom";
import {useEffect} from "react";

import {useUserStore} from "../stores/users.store.js";

import ProfileCard from "../components/profile/ProfileCard.jsx";

import {FaSearch, FaUsersSlash} from "react-icons/fa";

const HomePage = () => {
    const {fetchUsers, users} = useUserStore();
    useEffect(() => {
        fetchUsers();
    }, [fetchUsers]);

    return (
        <Container
            maxW='container.xl'
            py={{base: 6, md: 10}}
            px={{base: 4, md: 8}}
        >
            <VStack gap={8} align="stretch">
                <VStack align="flex-start" gap={1}>
                    <Text fontSize="3xl" fontWeight="800" letterSpacing="-0.02em" color="text.primary">
                        Developer profiles
                    </Text>
                    <Text color="text.secondary" fontSize="md">
                        Explore and connect with talented developers
                    </Text>
                </VStack>

                <InputGroup
                    width="full"
                    size="lg"
                    startElement={<FaSearch color="gray.400"/>}
                >
                    <Input
                        placeholder="Search by name, role, or skills..."
                        borderRadius="xl"
                        bg="bg.card"
                        border="1px solid"
                        borderColor="border.subtle"
                        _focus={{borderColor: "brand.500", boxShadow: "0 0 0 1px var(--chakra-colors-brand-500)"}}
                    />
                </InputGroup>

                <SimpleGrid
                    columns={{base: 1, sm: 2, lg: 3}}
                    gap={{base: 4, md: 6}}
                    w="full"
                >
                    {
                        users.map((user) => (
                            <ProfileCard key={user.id} user={user}/>
                        ))}
                </SimpleGrid>

                {users.length === 0 && (
                    <Text fontSize='x1'
                          textAlign={'center'}
                          fontWeight='bold'
                          color={'gray.500'}
                          display="flex"
                          alignItems="center"
                          justifyContent="center"
                          gap={2}>
                        No CV found
                        <span style={{color: 'gray', display: 'flex', alignItems: 'center'}}> 
                        <FaUsersSlash/>
                    </span>
                        <Link to={"/create"}>
                            <Text as='span' color={'teal.500'} _hover={{textDecoration: 'underline'}}>Create profile</Text>
                        </Link>
                    </Text>
                )}
            </VStack>
        </Container>
    );
};

export default HomePage;