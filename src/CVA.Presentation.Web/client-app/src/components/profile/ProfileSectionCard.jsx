import {Box, Container} from "@chakra-ui/react";

const ProfileSectionCard = ({children, ...props}) => {
    return (
        <Container
            maxW="container.lg"
            px={{base: 6, md: 8}}
            py={{base: 6, md: 8}}
            bg="bg.card"
            borderRadius="card"
            border="1px solid"
            borderColor="border.subtle"
            boxShadow="soft"
            transition="all 0.2s ease"
            {...props}
        >
            <Box position="relative" zIndex={1}>
                {children}
            </Box>
        </Container>
    )
};

export default ProfileSectionCard;
